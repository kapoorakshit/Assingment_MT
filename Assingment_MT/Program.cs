using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

class Program
{
    public static void SendEmail(string email, string body)
    {
        if (String.IsNullOrEmpty(email))
            return;
        try
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("kapoorakshit136@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Hello World";
                mail.IsBodyHtml = true;
                mail.Body = body;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("kapoorakshit136@gmail.com", "cjjtiyyqydtvpsie");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void Main()
    {
        // List of email addresses to send emails to
        string[] emailAddresses = {
            "kapoorakshit136@gmail.com",
            "kapoorakshit136@gmail.com",
            "kapoorakshit136@gmail.com",
            "kapoorakshit136@gmail.com",
            "kapoorakshit136@gmail.com",
            "kapoorakshit136@gmail.com",
            "kapoorakshit136@gmail.com",
            "kapoorakshit136@gmail.com",
            "kapoorakshit136@gmail.com",
            "kapoorakshit136@gmail.com"
            // Add more email addresses here...
        };

        // Body of the email
        string emailBody = "hii i sent you an email by a console app";

        // Send emails using threads
        Thread[] threads = new Thread[emailAddresses.Length];
        for (int i = 0; i < emailAddresses.Length; i++)
        {
            int index = i; 
            threads[i] = new Thread(() => SendEmail(emailAddresses[index], emailBody));
            threads[i].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("Main thread ended.");
        Console.ReadLine();
    }
}
