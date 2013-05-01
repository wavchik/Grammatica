using System.Data.Entity;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Utils;

namespace KakPishetsya.Common.Data.Context
{
    public class GrammaticaInitializer : CreateDatabaseIfNotExists<GrammaticaContext>
    {
        protected override void Seed(GrammaticaContext context)
        {
            base.Seed(context);

            var ruleNounSuffix = new Rule
                {
                    Name = "Гласные после шипящих",
                    Description =
                                "В суффиксах существительных, таких как:"
                                + "<br />"
                                + "-ок, пример: гребешок, крючок, сверчок, рожок;"
                                + "<br />"
                                + "-онок, пример: медвежонок, зайчонок, бельчонок;"
                                + "<br />"
                                + "-онк-а, пример: рубашонка, мальчонка, деньжонки, девчонки."
                                + "<br />"
                                + "Если после шипящих согласных ч, ж, щ, ш следует гласная О под ударением, то и пишется буква О."
                };
            context.Rules.Add(ruleNounSuffix);

            var ruleParticalTaki = new Rule
            {
                Name = "Написание частицы таки",
                Description = 
                            "Частица -таки пишется через дефис:"
                            + "<br />"
                            + "- после глаголов — уговорили-таки, явился-таки;"
                            + "<br />"
                            + "- после наречий — верно-таки, долго-таки, опять-таки, снова-таки;"
                            + "<br />"
                            + "- после частиц — все-таки, довольно-таки, неужели-таки, прямо-таки."
                            + "<br />"
                            + "В остальных случаях частица таки пишется раздельно."
            };
            context.Rules.Add(ruleParticalTaki);

            var wordKogda = new Word
            {
                Name = "когда-либо",
                SmartName = "kogda-libo",
                InvalidDescription = "когда либо",
                Explanation = "Запомни: то, либо, нибудь через дефис, как-то, кто-то, как-нибудь, как-либо."
            };
            context.Words.Add(wordKogda);

            var wordChtoby = new Word
            {
                Name = "Чтобы",
                SmartName = "chtoby",
                InvalidDescription = "Что бы/Чтобы",
                Explanation = "Есть два варианта: слитно ( например: пришел, чтобы попрощаться) и раздельно ( например: Что бы ему такое подарить? ). Если можете опустить бы, то пишется раздельно." +
                              "<br /><br />Пришел, чтобы попрощаться.<br /> Что бы ему такое подарить?"
                //SpellingExample = "Пришел, чтобы попрощаться.<br /> Что бы ему такое подарить?"
            };
            context.Words.Add(wordChtoby);

            var wordVseTaki = new Word
            {
                Name = "Все-таки",
                SmartName = "vse-taki",
                Explanation = @"всегда пишется через дефис",
                InvalidDescription = "Все таки",
                Rule = ruleParticalTaki
            };
            context.Words.Add(wordVseTaki);

            var wordNakonez = new Word
            {
                Name = "наконец-то",
                SmartName = "nakonez-to",
                InvalidDescription = "наконец то",
                Explanation = "Словосочетание наконец-то пишется через дефис, так как частица -то всегда пишется через дефис, наряду с такими, как: -либо, -таки, -нибудь и другими."
            };
            context.Words.Add(wordNakonez);

            var wordGirls = new Word
            {
                Name = "девчонки",
                SmartName = "devchenki",
                InvalidDescription = "девчёнки",
                Explanation = "пишется через \"о\"",
                Rule = ruleNounSuffix
            };
            context.Words.Add(wordGirls);

            var saltedHash = new SaltedHash("P@ssw0rd");

            var admin = new User()
            {
                Login = "admin",
                Password = "P@ssw0rd"
            };

            context.Users.Add(admin);
        }
    }
}