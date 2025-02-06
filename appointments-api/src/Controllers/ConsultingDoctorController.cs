using Interfaces;
using UseCases;
using Presenters;
using System.Globalization;
using System.Text;

namespace Controllers;
public class ConsultingDoctorController(IUserDBGateway userDbGateway, ICache cacheGateway) : IDoctorController
{
    public async Task<ResultDto<List<UserDto>>> ConsultingDoctorAsync(string specialty, int? score)
    {
        specialty = NormalizeText(specialty);
        var doctorCache = await cacheGateway.GetCacheAsync("Doctors");

        var useCase = new ConsultingDoctorUseCase();

        if (doctorCache is not null && doctorCache.Count > 0)
            return FilterList(specialty, score, useCase.CreateConsultingFromCache(doctorCache));

        var doctorList = await userDbGateway.FindAllAsync(w => w.CRM != null && w.Amount != null && w.Specialty != null && w.Score.HasValue);
        var result = useCase.CreateConsultingFromDb(doctorList);

        await cacheGateway.SaveCacheAsync("Doctors", result.Data);
        return FilterList(specialty, score, result);
    }

    private ResultDto<List<UserDto>> FilterList(string specialty, int? score, ResultDto<List<UserDto>> list)
    {
        if (score.HasValue && !string.IsNullOrEmpty(specialty))
            list.Data = list.Data.Where(f => f.Score == score.Value && f.Specialty == specialty).ToList();
        if (!string.IsNullOrEmpty(specialty))
            list.Data = list.Data.Where(f => f.Specialty == specialty).ToList();
        else if (score.HasValue)
        {
            list.Data = list.Data.Where(f => f.Score == score.Value).ToList();
        }

        return list;
    }

    private string NormalizeText(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        string normalizedString = input.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new();

        foreach (char c in normalizedString)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }
        return sb.ToString().ToUpperInvariant();
    }
}