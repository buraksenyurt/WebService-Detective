namespace AmigaWorld
{
    public class EmailService // Bu sınıf ele alınmamalı
    {
        public string MailServer { get; set; }
        public void SendMail(string to, string cc,string from,string body)
        {

        }
        public bool PingMailServer()
        {
            return false;
        }
    }
}