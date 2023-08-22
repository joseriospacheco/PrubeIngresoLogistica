using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.Utils;

public static class GenerarorNumeroGuia
{
    public static string GenerarNumeroGuia() {

        var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var Charsarr = new char[10];
        var random = new Random();

        for (int i = 0; i < Charsarr.Length; i++)
        {
            Charsarr[i] = characters[random.Next(characters.Length)];
        }


       
        return new String(Charsarr);
    }
}
