namespace LancheMVC.Helps
{
    public static class Percent
    {




        public static double porcentagemArrombada(this double number, int percent)
        {
            //return ((double) 80         *       25)/100;
            return (double)number / percent * 100;
        }

    }
}
