using System.Text;

namespace HelpingHand
{
    public static class HConsole
    {
        public static void StarRow(int stars = 50)
        {
            StringBuilder starBuilder = new StringBuilder();
            for(int i = 0; i < stars; i++)
            {
                starBuilder.Append("*");
            }
            Console.WriteLine(starBuilder.ToString());
        }
    }
}