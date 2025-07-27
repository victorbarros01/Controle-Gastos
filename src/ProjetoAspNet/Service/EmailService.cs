namespace ProjetoAspNet.Service {
    public class EmailService {

        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public EmailService(string server, int port, string username, string password) {
            Server = server;
            Port = port;
            Username = username;
            Password = password;
        }
    }
}
