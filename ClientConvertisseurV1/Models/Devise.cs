using System.ComponentModel.DataAnnotations;

namespace ClientConvertisseurV1.Models
{
    public class Devise
    {
        private int id;
        private string? nomDevise;
        private double taux;

        public int Id { get => id; set { id = value; } }
        public string NomDevise { get => nomDevise; set { nomDevise = value; } }
        public double Taux { get => taux; set { taux = value; } }

        public Devise(int id, string? nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }

        public override bool Equals(object? obj)
        {
            return obj is Devise devise &&
                   Id == devise.Id &&
                   NomDevise == devise.NomDevise &&
                   Taux == devise.Taux;
        }

        public override string ToString()
        {
            return this.NomDevise;
        }
    }
}
