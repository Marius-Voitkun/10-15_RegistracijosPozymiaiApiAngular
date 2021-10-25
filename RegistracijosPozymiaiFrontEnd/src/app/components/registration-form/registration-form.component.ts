import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Feature } from 'src/app/models/feature';
import { FormRecord } from 'src/app/models/form-record';
import { FeaturesService } from 'src/app/services/features.service';
import { FormValuesService } from 'src/app/services/form-values.service';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit, OnChanges {
  @Input('formId') formId: string = '1';

  private featuresService: FeaturesService;
  private formValuesService: FormValuesService;

  public features: Feature[] = [];
  public savedFormData!: FormRecord;

  public editMode: boolean = false;

  constructor(featuresService: FeaturesService, formValuesService: FormValuesService) {
    this.featuresService = featuresService;
    this.formValuesService = formValuesService;
  }

  async ngOnInit(): Promise<void> {
    await this.getFeaturesAsync();
    await this.getSavedFormDataAsync(parseInt(this.formId));
    this.setSavedValues();
  }

  async ngOnChanges(changes: SimpleChanges): Promise<void> {
    await this.getSavedFormDataAsync(parseInt(this.formId));
    this.setSavedValues();
    this.editMode = false;
  }

  private async getFeaturesAsync(): Promise<void> {
    this.features = await this.featuresService.getFeatures().toPromise();
  }

  private async getSavedFormDataAsync(id: number): Promise<void> {
    this.savedFormData = await this.formValuesService.getData(id).toPromise();
  }

  public setSavedValues(): void {
    this.features.forEach(feature => {
      let selectedOptionId = this.savedFormData.selectedValues[feature.id.toString()];
      feature.selectedOptionId = selectedOptionId ? selectedOptionId : 0;
    });
  }

  public async updateRecords(): Promise<void> {
    let selectedValues = {};
    this.features.forEach(feature => {
      if (feature.selectedOptionId)
        selectedValues[feature.id] = feature.selectedOptionId;
    });

    this.savedFormData.selectedValues = selectedValues;
    await this.formValuesService.updateData(this.savedFormData, this.savedFormData.id).toPromise();
  }
}
