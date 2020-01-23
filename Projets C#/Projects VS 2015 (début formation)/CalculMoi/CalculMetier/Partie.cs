﻿using CalculMetier.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculMetier
{
    public class Partie
    {
        // Champs
        public static int LIMITE_NOMBRE_QUESTIONS = 100;
        public static int LIMITE_MEMBRE_OPERATIONS = 1000;

        //public Partie(int nombremax, int nombrequestions)
        //{
        //    this.NombreMaxDesValeurs = nombremax;
        //    this.NombreDeQuestions = nombrequestions;
        //}

        public EtatPartieEnum Etat { get; private set; } = EtatPartieEnum.Pas_Commencee;

        private int _NombreDeQuestions = 10;
        public int NombreDeQuestions
        {
            get
            {
                return _NombreDeQuestions;
            }
            set
            {
                // Je vérifie les valeurs possibles pour NombreDeQuestions
                if (value < 1)
                {
                    throw new ArgumentException("Le nombre de questions doit être au moins égal à 1");
                }
                if (Etat != EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("Le nombre de questions ne peut pas être modifiée si la partie est commencée");
                }
                _NombreDeQuestions = value;
            }
        }

        private int _NombreMaxDesValeurs = 10;

        public int NombreMaxDesValeurs
        {
            get
            {
                return _NombreMaxDesValeurs;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Le max des valeurs doit être au moins égal à 1");
                }
                if (Etat != EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("Le max des valeurs ne peut pas être modifié si la partie est commencée");
                }
                _NombreMaxDesValeurs = value;
            }
        }

        public List<Question> Questions { get; private set; } = new List<Question>();


        public void Commencer()
        {
            if (Etat != EtatPartieEnum.Pas_Commencee)
            {
                throw new Exception("La partie est déjà commencée");

            }
            this.Etat = EtatPartieEnum.En_Cours;

        }

        public Question GetProchaineQuestion()
        {
            if (Etat == EtatPartieEnum.Pas_Commencee)
            {
                Commencer();
            }

            if (Etat != EtatPartieEnum.En_Cours)
            {
                throw new InvalidOperationException("La partie n'est pas en cours");
            }
            if (this.Questions.Any(q => q.DateReponse == null))
            {
                throw new InvalidOperationException("Répondez à la question posée");
            }


            Question questionARepondre = new Question(this.NombreMaxDesValeurs);
            Questions.Add(questionARepondre);
            return questionARepondre;
        }
        public bool Repondre(int reponse)
        {
            if (Etat != EtatPartieEnum.En_Cours)
            {
                throw new InvalidOperationException("La partie n'est pas en cours");

            }
            if (!Questions.Any(q => q.DateReponse == null))
            {
                throw new InvalidOperationException("Je ne vous ai pas donné de question");
            }

            Question questionSansReponse = Questions.FirstOrDefault(q => q.DateReponse == null);

            if (questionSansReponse == null)
            {
                throw new InvalidOperationException("Je ne vous ai pas donné de question");
            }

            questionSansReponse.NombreDeTentativesDeReponse++;

            if (reponse == questionSansReponse.BonneReponse)
            {
                questionSansReponse.DateReponse = DateTime.Now;
                questionSansReponse.TempsDeReponse = (questionSansReponse.DateReponse.Value - questionSansReponse.DateQuestionPosee).TotalMilliseconds;

                if (this.Questions.Count == NombreDeQuestions)
                {
                    this.Etat = EtatPartieEnum.Terminee;
                }
                return true;
            }
    
                return false;
          
        }


        public double ScoreTemps
        {
            get
            {
                if (!Questions.Any(q => q.DateReponse != null))
                {
                    throw new InvalidOperationException("Le score n'est disponible que lorsque il y a au moins une question répondue");
                }
                if (this.Etat != EtatPartieEnum.Terminee)
                {
                    throw new InvalidOperationException("Vous ne pouvez pas obtenir de score si la partie n'est pas finie");
                }

                return Math.Round(Questions.Where(q => q.DateReponse != null).Average(q => ((DateTime)q.DateReponse - q.DateQuestionPosee).TotalMilliseconds));
            }
        }
        public double ScoreEssais
        {
            get
            {
                if (!Questions.Any(q => q.DateReponse != null))
                {
                    throw new InvalidOperationException("Le score n'est disponible que lorsque il y a au moins une question répondue");
                }
                if (this.Etat != EtatPartieEnum.Terminee)
                {
                    throw new InvalidOperationException("Vous ne pouvez pas obtenir de score si la partie n'est pas finie");
                }

                return Questions.Where(q => q.DateReponse != null).Average(q => (double)q.NombreDeTentativesDeReponse);
            }
        }
    }
}
