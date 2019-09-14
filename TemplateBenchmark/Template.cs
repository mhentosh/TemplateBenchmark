using System;
using System.Collections.Generic;

namespace TemplateBenchmark
{
    internal class Template
    {
        public static Dictionary<string, string> TemplateData = new Dictionary<string, string>
        {
            { "{FirstName}", "Joe"},
            { "{LastName}", "Doe" },
            { "{PhoneNumber}", "555-555-5555"},
            { "{Zip}", "78765"},
            { "{St}", "CA"},
            { "{City}", "Newport Beach"},
            { "{Address1}", "123 Main Street"},
            { "{Email}", "jdoe@mail.com"},
            { "{ClientCompany}", "Acme Office Supplies"},
            { "{ClientPosition}", "Director"},
            { "{ClientDepartment}", "Human Resources"},
            { "{ClientFirstName}", "Steven"},
            { "{ClientLastName}", "Kramer" },
            { "{ClientAddress2}", "" },
            { "{ClientAddress1}", "123 Business Rd." },
            { "{ClientSt}", "NY" },
            { "{ClientZip}", "12354"},
            { "{ClientCity}", "Business City"},
            { "{ConferenceDate}", DateTime.Now.AddDays(10).ToLongDateString()},
            { "{LetterDate}", DateTime.Now.ToShortDateString()}
        };

        public const string Value =
@"{FirstName} {LastName}
{Address1}
{City}, {State} {Zip}
{PhoneNumber} 
{Email}

{LetterDate}

{ClientFirstName} {ClientLastName}
{ClientPosition}, {ClientDepartment}
{ClientCompany}
{ClientAddress1} 
{ClientCity}, {ClientSt} {ClientZip}

Dear Mr. {ClientLastName},

I’m writing today to invite you or another representative from your company to speak at the annual Metropolitan Business Conference, which will be held at North Branch Hotel, {ConferenceDate}.

The theme of our upcoming conference is finding and hiring employees who fit company culture. With the growth that your company has seen in the past five years, I believe you would have much to offer our audience.

As part of the speaker’s package, we offer a modest honorarium and a table for six at the Saturday night dinner.

If you have any questions or wish to know more about the speaking opportunity, please let me know. My cell phone number is {PhoneNumber}, and my email is {Email}.

I look forward to hearing from you.Thank you for your consideration.

Sincerely,

Your signature (hard copy letter)

{FirstName} {LastName}";
    }
}
