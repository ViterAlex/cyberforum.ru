namespace ProfAndDiploms
{
    public class Diploma
    {
        public Student Student { get; set; }
        public string Topic { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return $"{Topic} {Student}";
        }

        #endregion
    }
}