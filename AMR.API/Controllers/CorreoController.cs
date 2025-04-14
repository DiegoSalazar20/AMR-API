using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AMR.Dominio;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorreoController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DatosCorreoElectronico datos)
        {
            if (datos == null)
            {
                return BadRequest("Solicitud inválida.");
            }

            string subject = $"Confirmación de Reserva: {datos.CodigoReserva}";
            string body = $@"
            <html>
                <head>
                  <style>
                    body {{
                      font-family: Arial, sans-serif;
                      color: #333;
                      margin: 0;
                      padding: 0;
                    }}
                    .container {{
                      padding: 20px;
                    }}
                    .header {{
                      background-color: #f7bf7a;
                      padding: 15px;
                      text-align: center;
                      color: #3E5975;
                    }}
                    .content {{
                      margin: 20px 0;
                      line-height: 1.5;
                    }}
                    .content ul {{
                      list-style: none;
                      padding-left: 0;
                    }}
                    .content li {{
                      margin-bottom: 8px;
                    }}
                    .footer {{
                      font-size: 12px;
                      color: #666;
                      text-align: center;
                      border-top: 1px solid #ddd;
                      padding-top: 10px;
                      margin-top: 20px;
                    }}
                  </style>
                </head>
            <body>
              <div class='container'>
                <div class='header'>
                  <h1>Arena &amp; Mar Resort</h1>
                </div>
                <div class='content'>
                  <p>Estimado/a {datos.Nombre} {datos.Apellidos},</p>
                  <p>Nos complace confirmarle que su reserva ha sido registrada exitosamente.</p>
                  <p>Su código de reserva es: <strong>{datos.CodigoReserva}</strong></p>
                  <p><strong>Detalles de la Reserva:</strong></p>
                  <ul>
                    <li>Tipo de habitación: {datos.TipoHabitacion}</li>
                    <li>Ckeck-in: {datos.FechaLlegada:dd-MM-yyyy} a la 1:00pm</li>
                    <li>Check-out: {datos.FechaSalida:dd-MM-yyyy} a las 11:00am</li>
                  </ul>
                  <p>Si tiene alguna pregunta o requiere asistencia, por favor no dude en contactarnos.</p>
                  <p>¡Gracias por elegir Arena &amp; Mar Resort!</p>
                </div>
                <div class='footer'>
                  <p>© 2025 Arena &amp; Mar Resort. Todos los derechos reservados.</p>
                </div>
              </div>
            </body>
            </html>";

            try
            {
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential("dsalazarzamora2001@gmail.com", "lcsx wbnh zwct djsr");

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("dsalazarzamora2001@gmail.com", "Arena & mar resort"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };
                    mailMessage.To.Add(datos.Correo);

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al enviar el correo: " + ex.Message);
            }

            return Ok("Correo enviado exitosamente.");
        }
    }
}
