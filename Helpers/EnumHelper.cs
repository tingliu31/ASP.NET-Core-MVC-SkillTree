using System.ComponentModel.DataAnnotations;

namespace Homework_SkillTree.Helpers
{
    public class EnumHelper
    {
        public static string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field?.GetCustomAttributes(typeof(DisplayAttribute), false)
                             .Cast<DisplayAttribute>()
                             .FirstOrDefault();
            return attr?.Name ?? value.ToString();
        }

    }
}
