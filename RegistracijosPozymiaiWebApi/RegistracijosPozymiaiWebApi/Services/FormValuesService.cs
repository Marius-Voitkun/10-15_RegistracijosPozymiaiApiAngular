using RegistracijosPozymiaiWebApi.DAL;
using RegistracijosPozymiaiWebApi.Dtos;
using RegistracijosPozymiaiWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistracijosPozymiaiWebApi.Services
{
    public class FormValuesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FormValuesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FormValuesDto>> GetAllDataAsync()
        {
            var allRecords = await _unitOfWork.SelectedValues.GetAllAsync(null);
            var formIds = allRecords.Select(v => v.FormId).Distinct().OrderBy(v => v).ToList();
            var formDtos = new List<FormValuesDto>();

            foreach (var formId in formIds)
            {
                var recordsForForm = allRecords.Where(v => v.FormId == formId).ToList();
                formDtos.Add(GenerateFormDto(formId, recordsForForm));
            }

            return formDtos;
        }

        public async Task<FormValuesDto> GetByFormIdAsync(int id)
        {
            var records = await _unitOfWork.SelectedValues.GetFilteredAsync(v => v.FormId == id, null);
            return GenerateFormDto(id, records);
        }

        private FormValuesDto GenerateFormDto(int formId, List<SelectedValue> records)
        {
            var formDto = new FormValuesDto
            {
                Id = formId,
                SelectedValues = new()
            };

            foreach (var record in records)
            {
                formDto.SelectedValues.Add(record.FeatureId, record.DropDownOptionId);
            }

            return formDto;
        }

        public async Task UpdateAsync(int id, FormValuesDto formDto)
        {
            var oldValues = await _unitOfWork.SelectedValues.GetFilteredAsync(v => v.FormId == id, null);
            _unitOfWork.SelectedValues.DeleteRange(oldValues);

            var newValues = new List<SelectedValue>();

            foreach (var record in formDto.SelectedValues.Where(v => v.Value != 0))
            {
                newValues.Add(new SelectedValue
                {
                    FormId = id,
                    FeatureId = record.Key,
                    DropDownOptionId = record.Value
                });
            }

            _unitOfWork.SelectedValues.AddRange(newValues);
            await _unitOfWork.SaveAsync();
        }
    }
}
