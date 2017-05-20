namespace ProfAndDiploms
{
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return $"{Group}, {Name}";
        }

        #endregion
    }
}