namespace DcsMissionParser.CSharp.Objects.Drawings
{
    public class Layer
    {

        public bool Visible { get; set; }
        public string? Name { get; set; }

        public List<DrawingObject> Objects { get; set; } = [];

    }
}
