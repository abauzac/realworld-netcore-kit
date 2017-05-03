using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Sandbox.Server.BusinessLogic.Handlers.Abstract;
using Sandbox.Server.DomainObjects.Interfaces.Handlers;
using Sandbox.Server.DomainObjects.Interfaces.Repositories;
using Sandbox.Server.DomainObjects.Interfaces.Repositories.Abstract;
using Sandbox.Server.DomainObjects.Models;

namespace Sandbox.Server.BusinessLogic.Handlers
{
    public class ArticleHandler : EntityHandler<Article, IEntityRepository<Article>>, IArticleHandler
    {
        public ArticleHandler(IArticleRepository repository) : base(repository)
        {
        }

        public override async Task<Article> Create(Article entity)
        {
            entity.Slug = NormalizeStringForUrl(entity.Title);

            return await _repository.Create(entity);
        }

        private static string NormalizeStringForUrl(string name)
        {
            String normalizedString = name.ToLowerInvariant().Normalize(NormalizationForm.FormC);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                switch (CharUnicodeInfo.GetUnicodeCategory(c))
                {
                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.UppercaseLetter:
                    case UnicodeCategory.DecimalDigitNumber:
                        stringBuilder.Append(c);
                        break;
                    case UnicodeCategory.SpaceSeparator:
                    case UnicodeCategory.ConnectorPunctuation:
                    case UnicodeCategory.DashPunctuation:
                        stringBuilder.Append('-');
                        break;
                }
            }
            string result = stringBuilder.ToString();
            return String.Join("-", result.Split(new char[] { '-' }
                , StringSplitOptions.RemoveEmptyEntries)); 
        }
    }
}