using System;
using TDE;
    class Tarefa
    {
        public string Titulo { get; set; }
        public bool Concluida { get; set; }

        public Tarefa(string titulo)
        {
            Titulo = titulo;
            Concluida = false; // Por padrão, a tarefa é criada como "não concluída"
        }
    }