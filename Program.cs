namespace GameAssignment
{
    class Program
    {
        static void Main(String[] args)
        {
            try
            {
                Game.StartGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}