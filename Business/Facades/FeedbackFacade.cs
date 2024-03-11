using Business.DTOs;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Business.Facades
{
    public class FeedbackFacade
    {
        private readonly LogicalcDbContext _context;

        public FeedbackFacade(LogicalcDbContext context)
        {
            _context = context;
        }

        public async Task<FeedbackDto> GetQuestionsAsync()
        {
            var result = new FeedbackDto();

            await InitilaizeQuestionsAsync();

            var questions = await _context.Questions.OrderBy(x => x.Order).Select(x => new QuestionDto()
            {
                Text = x.Text,
                Id = x.Id
            }).ToListAsync();

            result.Questions = questions;
            return result;
        }

        public async Task<bool> PostFeedbackAsync(FeedbackDto feedbackDto)
        {
            var f = new Feedback
            {
                Improvement = feedbackDto.Improvement,
                Bug = feedbackDto.Bug
            };
            var questions = JsonConvert.SerializeObject(feedbackDto.Questions);
            f.Questions = questions;

            _context.Add(f);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task InitilaizeQuestionsAsync()
        {
            var count = _context.Questions.Count();
            if(count > 0)
            {
                return;
            }

            var list = new List<Question>();
            var strings = new List<string>()
            {
                "Aký bol Váš prvý dojem z aplikácie?",
                "Ako hodnotíte designovú stránku aplikácie?",
                "Ako hodnotíte všeobecnú navigáciu po stránke?",
                "Bolo jednoduché prepnúť farebnú schému a svetlý/tmavý mód?",
                "Bolo jednoduché registrovať sa a prihlásiť sa?",
                "Bol formát zadávania dostatočne jasný?",
                "Použili ste na zadávanie vstupu pomocnú klávesnicu?",
                "Aká bola intuitívnosť zadávania vstupnej formuly/klauzuly?",
                "Použili ste klávesové skratky?",
                "Ako hodnotíte presnosť výsledkov riešenia formúl?",
                "Aká bola intuitívnosť rozhrania interaktívneho rezolvovania?",
                "Aký bol výkon aplikácie z hľadiska rýchlosti a odozvy?",
                "Máte pocit, že by ste na použitie aplikácie potrebovali hlbšie znalosti z oblasti výrokovej alebo predikátovej logiky?",
                "Odporučili by ste aplikáciu svojim známym/spolužiakom?",
                "Použili by ste aplikáciu znovu?",
            };

            var order = 0;
            foreach (var s in strings)
            {
                list.Add(new Question { Text = s, Order = order++ });
            }

            await _context.Questions.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }
    }
}
