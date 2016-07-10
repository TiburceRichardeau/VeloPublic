using System;
using System.IO;

namespace VeloPublic
{
    /// <summary>
    /// Classe qui permet de créer des fichiers de log qui permettent de savoir ce qui se passe pendant l'éxécution de l'application
    /// </summary>
    /// <author>Tiburce Richardeau</author>
    public class Log
    {
        /// <summary>
        /// Attribut de la classe qui contient la date de création du log
        /// </summary>
        public DateTime date { get; set; }

        /// <summary>
        /// Attribut qui contient le message a stocker dans les logs
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// structure de données,
        /// permet de définir le type de log pour qu'il soit stocker dans le bon fichier de log
        /// les erreurs et infos sont stockés dans des fichiers différents
        /// </summary>
        public enum Type { Erreur , Infos, Autre }
        
        /// <summary>
        /// Type du log créer (Erreur, Infos ou Autre
        /// </summary>
        public Type t { get; set; }

        /// <summary>
        /// Constructeur de log
        /// Permet d'enregistrer dans un fichier log ce qui se passe dans l'application
        /// Les fichiers de logs sont stockés dans 
        ///         <code>VeloPublic\bin\x86\Debug\logs</code>
        /// ou dans 
        ///         <code>DossierdInstallation\logs</code>
        /// </summary>
        /// <param name="t">Contient le type de log (soit "Log.Type.Infos", soit "Log.Type.Erreur", soit "Log.Type.Autre"</param>
        /// <param name="message">Contient le message d'info ou d'erreur a enregistrer</param>
        public Log(Type t, string message)
        {
            try // Permet d'éviter de bugé l'application si les fichiers de log sont en lecture seule
            {
                // les fichiers de logs sont stockés dans VeloPublic\bin\x86\Debug\logs
                Directory.CreateDirectory("logs"); // Permet de créer le dossier qui contient les fichiers de logs si il n'existent pas


                date = DateTime.Now;
                this.t = t;
                this.message = message;

                // Log enregistrer dans le fichier principal
                EnregistrerLog();

                if (t == Type.Infos)
                {
                    EnregistrerInfo(); // Log enregistrer dans le fichier de log VeloPublicInfos.log
                }
                else if (t == Type.Erreur)
                {
                    EnregistrerErreur(); // Log enregistrer dans le fichier de log VeloPublicErreur.log
                }
            }
            catch
            {
                Erreur er = new Erreur();
                er.ShowDialog();
            }
        }

        /// <summary>
        ///  Permet d'enregister un log dans le fichier d'infos
        /// </summary>
        /// <returns>retourne la chaine de caractères écrite dans le fichier de log Infos : VeloPublicInfos.log</returns>
        private string EnregistrerInfo()
        {
            // Permet d'écrire dans le fichier log Infos
            string log = date + "\t" + "[Info]" + "\t" + "\t" + message + "\n";
            using (StreamWriter w = File.AppendText("logs\\VeloPublicInfos.log"))
            {
               w.Write(log);
            }
            return log;
        }

        /// <summary>
        /// Permet d'enregistrer un log dans le fichier d'erreur
        /// </summary>
        /// <returns>retourne la chaine de caractères écrite dans le fichier de log Erreur : VeloPublicErreur.log</returns>
        private string EnregistrerErreur()
        {
            string log = date + "\t" + "[Erreur]" + "\t" + message + "\n";
            using (StreamWriter w = File.AppendText("logs\\VeloPublicErreur.log"))
            {
                w.Write(log);
            }
            return log;
        }

        /// <summary>
        /// Permet d'enregistrer un log dans le fichier principal
        /// </summary>
        /// <returns>retourne la chaine de caractères écrite dans VeloPublic.log</returns>
        public string EnregistrerLog()
        {
            // Permet d'écrire dans le fichier log principal
            using (StreamWriter w = File.AppendText("logs\\VeloPublic.log"))
            {
                string logInfos = date + "\t" + "[Info]" + "\t" + "\t" + message + "\n";
                string logErreur = date + "\t" + "[Erreur]" + "\t" + message + "\n";
                string log = date + "\t" + "[Autre]" + "\t" + message + "\n";

                if (this.t == Log.Type.Infos)
                {
                    w.Write(logInfos);
                    return logInfos;
                }
                    
                else if (this.t == Log.Type.Erreur)
                {
                    w.Write(logErreur);
                    return logErreur;
                }
                else
                {
                    w.Write(log);
                    return log;
                }       
            }
        }
    }
}