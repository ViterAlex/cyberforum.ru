using System.Collections.Generic;
using System.Text;

namespace ProfAndDiploms
{
    public class Professor
    {
        public string Name { get; set; }
        public List<Diploma> Diplomas { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Name);
            foreach (var diploma in Diplomas)
            {
                sb.AppendLine($"\t{diploma.Topic}");
                sb.AppendLine($"\t\t{diploma.Student.Group}");
                sb.AppendLine($"\t\t{diploma.Student.Name}");
            }
            return sb.ToString();
        }

        #endregion
    }
}
