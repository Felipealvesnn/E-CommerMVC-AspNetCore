using LancheMVC_Aplication.DTOs;
using LancheMVC_Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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
