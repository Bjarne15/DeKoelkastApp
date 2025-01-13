using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeKoelkastApp.Services
{
    public class AppState
    {
        private static AppState _instance;

        public static AppState Instance => _instance ??= new AppState();

        // Eigenschap om de geselecteerde koelkast op te slaan
        public Models.Fridge SelectedFridge { get; set; }

        public Models.User SelectedUser { get; set; }

        private AppState() { }
    }
}
