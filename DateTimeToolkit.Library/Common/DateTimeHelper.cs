using System;
using System.Collections.Generic;
using System.Globalization;

namespace DateTimeToolkit.Library.Common
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Gets the weekend days for a specific culture.
        /// </summary>
        /// <param name="culture">The culture to determine weekend days.</param>
        /// <returns>An array of weekend days.</returns>
        internal static DayOfWeek[] GetWeekendDaysForCulture(CultureInfo culture)
        {
            if (CultureWeekendDays.TryGetValue(culture.Name, out var weekendDays))
            {
                return weekendDays;
            }

            // Default to Saturday and Sunday if culture is not specified
            return new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
        }



        private static readonly Dictionary<string, DayOfWeek[]> CultureWeekendDays = new Dictionary<string, DayOfWeek[]>
        {           
            // Asia
            { "zh-CN", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // China
            { "ja-JP", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Japan
            { "ko-KR", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // South Korea
            { "hi-IN", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // India
            { "ar-SA", new[] { DayOfWeek.Friday, DayOfWeek.Saturday } }, // Saudi Arabia
            { "ar-PS", new[] { DayOfWeek.Friday, DayOfWeek.Saturday } }, // Palestinian Territories (including Gaza)
            { "th-TH", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Thailand
            { "vi-VN", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Vietnam
            { "id-ID", new[] { DayOfWeek.Friday, DayOfWeek.Saturday } }, // Indonesia
            { "fa-IR", new[] { DayOfWeek.Thursday, DayOfWeek.Friday } }, // Iran

            // Americas
            { "en-US", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // United States
            { "en-CA", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Canada
            { "es-MX", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Mexico
            { "pt-BR", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Brazil
            { "es-AR", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Argentina

            // Europe
            { "en-GB", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // United Kingdom
            { "fr-FR", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // France
            { "de-DE", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Germany
            { "it-IT", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Italy
            { "es-ES", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Spain
            { "pt-PT", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Portugal
            { "nl-NL", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Netherlands
            { "pl-PL", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Poland
            { "ru-RU", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Russia
            { "tr-TR", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Turkey
            { "el-GR", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Greece

            // Africa
            { "en-ZA", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // South Africa
            { "fr-DZ", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Algeria
            { "sw-KE", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Kenya
            { "ar-EG", new[] { DayOfWeek.Friday, DayOfWeek.Saturday } }, // Egypt
            { "pt-AO", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Angola
            { "am-ET", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Ethiopia
            { "fr-CI", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Ivory Coast

            // Oceania
            { "en-AU", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Australia
            { "en-NZ", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // New Zealand
            { "fr-PF", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // French Polynesia
            { "es-CL", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Chile

            // Additional Cultures
            { "af-ZA", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Afrikaans - South Africa
            { "sq-AL", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Albanian - Albania
            { "hy-AM", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Armenian - Armenia
            { "az-AZ", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Azerbaijani - Azerbaijan
            { "eu-ES", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Basque - Spain
            { "be-BY", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Belarusian - Belarus
            { "bs-BA", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Bosnian - Bosnia and Herzegovina
            { "bg-BG", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Bulgarian - Bulgaria
            { "ca-ES", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Catalan - Spain
            { "hr-HR", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Croatian - Croatia
            { "cs-CZ", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Czech - Czech Republic
            { "da-DK", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Danish - Denmark
            { "nl-BE", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Dutch - Belgium
            { "et-EE", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Estonian - Estonia
            { "fi-FI", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Finnish - Finland
            { "ka-GE", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Georgian - Georgia
            { "gl-ES", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Galician - Spain
            { "hu-HU", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Hungarian - Hungary
            { "is-IS", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Icelandic - Iceland
            { "ga-IE", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Irish - Ireland
            { "lv-LV", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Latvian - Latvia
            { "lt-LT", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Lithuanian - Lithuania
            { "mk-MK", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Macedonian - North Macedonia
            { "ms-MY", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Malay - Malaysia
            { "mt-MT", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Maltese - Malta
            { "mn-MN", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Mongolian - Mongolia
            { "ne-NP", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Nepali - Nepal
            { "no-NO", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Norwegian - Norway
            { "ps-AF", new[] { DayOfWeek.Friday, DayOfWeek.Saturday } }, // Pashto - Afghanistan
            { "ro-RO", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Romanian - Romania
            { "sr-RS", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Serbian - Serbia
            { "sk-SK", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Slovak - Slovakia
            { "sl-SI", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Slovenian - Slovenia
            { "so-SO", new[] { DayOfWeek.Friday, DayOfWeek.Saturday } }, // Somali - Somalia
            { "sv-SE", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Swedish - Sweden
            { "tl-PH", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Tagalog - Philippines
            { "tg-TJ", new[] { DayOfWeek.Friday, DayOfWeek.Saturday } }, // Tajik - Tajikistan
            { "uk-UA", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Ukrainian - Ukraine
            { "ur-PK", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Urdu - Pakistan
            { "uz-UZ", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Uzbek - Uzbekistan
            { "cy-GB", new[] { DayOfWeek.Saturday, DayOfWeek.Sunday } }, // Welsh - United Kingdom
        };

    }
}
