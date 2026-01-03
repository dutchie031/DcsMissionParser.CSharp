-- 1) Define theatre bounds (per theatre)

local getBounds = function()
    if env.mission.theatre == "Caucasus" then
        return {
            topLeft     = { x = 0.0, z = 0.0, y = 0.0 },
            topRight    = { x =  0.0, z = 900000, y = 0.0 },
            bottomLeft  = { x = -561900, z = 0,    y = 0.0 },
            bottomRight = { x =  -561900, z = 900000,    y = 0.0 },
        }
    elseif env.mission.theatre == "GermanyCW" then
        return {
            topLeft     = { x = 130000.0, z = -1000000.0, y = 0.0 },
            topRight    = { x =  140000.0, z = -300000.0, y = 0.0 },
            bottomLeft  = { x = -530000.0, z = -1000000.0,    y = 0.0 },
            bottomRight = { x =  -530000.0, z = -300000.0,    y = 0.0 },
        }
    end
end

local bounds = getBounds()

local theatre = env.mission.theatre or "UNKNOWN"

---@class exportType
---@field public x number
---@field public z number
---@field public lat number
---@field public lon number

local function lerp(a, b, t)
    return a + (b - a) * t
end

local function makeGridPoints(bounds, nx, nz)
    local pts = {}

    for ix = 0, nx - 1 do
        local tx = nx == 1 and 0.5 or ix / (nx - 1)

        local topX    = lerp(bounds.topLeft.x,    bounds.topRight.x,    tx)
        local topZ    = lerp(bounds.topLeft.z,    bounds.topRight.z,    tx)
        local bottomX = lerp(bounds.bottomLeft.x, bounds.bottomRight.x, tx)
        local bottomZ = lerp(bounds.bottomLeft.z, bounds.bottomRight.z, tx)

        for iz = 0, nz - 1 do
            local tz = nz == 1 and 0.5 or iz / (nz - 1)

            local x = lerp(bottomX, topX, tz)
            local z = lerp(bottomZ, topZ, tz)

            table.insert(pts, { x = x, z = z, y = 0.0 })
        end
    end

    return pts
end

local function makeRandomTestPoints(bounds, count)
    local pts = {}

    -- Derive min/max for x and z from the bounds
    local minX = math.min(bounds.topLeft.x, bounds.bottomLeft.x, bounds.topRight.x, bounds.bottomRight.x)
    local maxX = math.max(bounds.topLeft.x, bounds.bottomLeft.x, bounds.topRight.x, bounds.bottomRight.x)
    local minZ = math.min(bounds.topLeft.z, bounds.bottomLeft.z, bounds.topRight.z, bounds.bottomRight.z)
    local maxZ = math.max(bounds.topLeft.z, bounds.bottomLeft.z, bounds.topRight.z, bounds.bottomRight.z)

    for _ = 1, count do
        local x = math.random(minX, maxX)
        local z = math.random(minZ, maxZ)
        table.insert(pts, { x = x, z = z, y = 0.0 })
    end

    return pts
end

local function exportSamplePoints()
    env.info("TM_EXPORT_BEGIN")

    local referencePoints = makeGridPoints(bounds, 5, 5)
    local testPoints = makeRandomTestPoints(bounds, 20)

    ---@type table
    local payload = {
        reference_points = {},
        test_points = {},
        theatre = theatre,
    }

    for _, point in ipairs(referencePoints) do
        local lat, lon = coord.LOtoLL(point)

        table.insert(payload.reference_points, {
            x = point.x,
            z = point.z,
            lat = lat,
            lon = lon,
        })
    end

    for _, point in ipairs(testPoints) do
        local lat, lon = coord.LOtoLL(point)

        table.insert(payload.test_points, {
            x = point.x,
            z = point.z,
            lat = lat,
            lon = lon,
        })
    end

    local json = net.lua2json(payload)
    env.info("json: " .. json)

    env.info("TM_EXPORT_END")
end

exportSamplePoints()