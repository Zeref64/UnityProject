using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using TMPro;

public class EmailPanel : MonoBehaviour
{
    public TMP_InputField emailInputField;
    public TMP_InputField subjectInputField;
    public TMP_InputField messageInputField;

    public void SendEmail()
    {
        string senderEmail = "unityapp13@gmail.com";
        string senderPassword = "aeinkugbdzehxyxh";
        string recipientEmail = emailInputField.text;
        string subject = subjectInputField.text;
        string message = messageInputField.text;

        MailMessage mail = new MailMessage();
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

        mail.From = new MailAddress(senderEmail);
        mail.To.Add(recipientEmail);
        mail.Subject = subject;
        mail.Body = message;

        smtpServer.Port = 587;
        smtpServer.Credentials = new NetworkCredential(senderEmail, senderPassword);
        smtpServer.EnableSsl = true;

        try
        {
            smtpServer.Send(mail);
            Debug.Log("Email sent successfully!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to send email: " + e.Message);
        }
    }

    public void CancelEmail()
    {
        // Clear input fields or perform any desired actions when canceling the email.
        emailInputField.text = "";
        subjectInputField.text = "";
        messageInputField.text = "";
    }
}
