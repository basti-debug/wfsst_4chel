using ChatserverLib;

namespace ChatserverApp
{
    internal class Program
    {

        

        static void Main(string[] args)
        {
            string currentuser = "admin";
            bool loggedin = false;
            string filename = "chat.sqlite";

            TCP_Chatserver tCP_Chatserver = new TCP_Chatserver(5000);
            tCP_Chatserver.start();
            tCP_Chatserver.initalisetable(filename);

            do
            {
                loggedin = tCP_Chatserver.login(filename);
            }
            while (loggedin == false);

           tCP_Chatserver.Listen(currentuser, filename);
           
        }
    }

}