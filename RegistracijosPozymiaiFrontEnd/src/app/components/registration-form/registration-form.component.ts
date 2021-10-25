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

  ngOnInit(): void {
    this.getFeatures();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.getSavedFormData(parseInt(this.formId));
  }

  private getFeatures() {
    this.featuresService.getFeatures().subscribe(featuresFromApi => {
      this.features = featuresFromApi;
      this.getSavedFormData(parseInt(this.formId));
    });
  }

  private getSavedFormData(id: number) {
    this.formValuesService.getData(id).subscribe(recordsFromApi => {
      this.savedFormData = recordsFromApi;
      this.setSavedValues();
    });
  }

  public setSavedValues() {
    this.features.forEach(feature => {
      let selectedOptionId = this.savedFormData.selectedValues[feature.id.toString()];
      feature.selectedOptionId = selectedOptionId ? selectedOptionId : 0;
    });
  }

  public updateRecords() {
    let selectedValues = {};
    this.features.forEach(feature => {
      if (feature.selectedOptionId)
        selectedValues[feature.id] = feature.selectedOptionId;
    });

    this.savedFormData.selectedValues = selectedValues;
    this.formValuesService.updateData(this.savedFormData, this.savedFormData.id).subscribe();
  }
}
