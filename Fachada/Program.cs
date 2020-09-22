using Neighlink.Entity;
using Neighlink.Service;
using Neighlink.Service.implementation;
using System;

namespace Fachada
{
    class Fachada
    {
        private INewService news;
        public Fachada()
        {
            news = new NewService();
        }
        public void buscar( String today)
        {
            news.GetAll();
        }
    }
}
