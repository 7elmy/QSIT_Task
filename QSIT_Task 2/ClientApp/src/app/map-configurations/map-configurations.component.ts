import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MapType } from 'src/app/models/MapType';
import { MapConfigurations } from 'src/app/models/MapConfigurations';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-map-configurations',
  templateUrl: './map-configurations.component.html',
  styleUrls: ['./map-configurations.component.css']
})
export class MapConfigurationsComponent implements OnInit {

  mapTypes: MapType[];
  mapSubTypes: MapType[];
  mapConfigurations: MapConfigurations;
  http: HttpClient;
  baseUrl: string;
  mapForm: FormGroup;
  MapTypeSelected = false;
  submitted = false;
  pageLoaded = false;
  mapTypeId = '';
  clusterRadiusErrorMsg = '';
  clusterRadiusError = false;


  constructor(private fb: FormBuilder, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
    this.getMapTypes();
    this.getMapConfigurations();
  }


  checkMsg() {
    if (this.mapForm.value.clusterRadius > 99 || this.mapForm.value.clusterRadius < 0.01) {
      this.clusterRadiusError = true;
      this.clusterRadiusErrorMsg = 'cluster Radius should be between 0.01 and 99';
    }
    else {
      this.clusterRadiusError = false;
      this.clusterRadiusErrorMsg = '';
    }
  }

  // convenience getter for easy access to form fields
  get f() { return this.mapForm.controls; }

  saveMapConfigurations() {
    this.submitted = true;

    if (this.mapForm.invalid) {
      return;
    }
    if (this.mapForm.value.clusterRadius > 99 || this.mapForm.value.clusterRadius < 0.01) {
      this.clusterRadiusError = true;
      this.clusterRadiusErrorMsg = 'cluster Radius should be between 0.01 and 99';
      return;
    }


    this.http.post(this.baseUrl + 'api/map/map-configurations', this.mapForm.value).subscribe(result => {
      alert("Saved successfully ")
    }, error => alert("All inputs accept max 3 decimal places "));
  }


  private createMapForm() {
    var mabSubTypeId = this.mapConfigurations.mapSubTypeId;
    this.mapForm = this.fb.group({
      mapSubTypeId: [mabSubTypeId > 0 ? mabSubTypeId:'', Validators.required],
      endEventDuration: [this.mapConfigurations.endEventDuration, Validators.required],
      duplicationEventLocationBuffer: [this.mapConfigurations.duplicationEventLocationBuffer, Validators.required],
      duplicationEventTimeBuffer: [this.mapConfigurations.duplicationEventTimeBuffer, Validators.required],
      geoFencing: [this.mapConfigurations.geoFencing, Validators.required],
      clusterRadius: [this.mapConfigurations.clusterRadius, [Validators.required]],
    });
  }

  onMapTypeChange(value) {
    this.MapTypeSelected = false;
    this.mapForm.controls.mapSubTypeId.setValue('');
    if (value != "") {
      this.getMapSubTypes(value as number);
    } else {
      this.mapSubTypes =[];
    }
  }


  private getMapConfigurations() {
    this.http.get<MapConfigurations>(this.baseUrl + 'api/map/map-configurations').subscribe(result => {
      this.mapConfigurations = result;
      if (this.mapConfigurations.mapTypeId > 0) {
        this.mapTypeId = this.mapConfigurations.mapTypeId.toString();
        this.http.get<MapType[]>(this.baseUrl + 'api/map/map-sub-types?parentId=' + this.mapConfigurations.mapTypeId).subscribe(result => {
          this.MapTypeSelected = true;
          this.mapSubTypes = result;
          this.createMapForm();
          this.pageLoaded = true
        }, error => console.error(error));
      } else {
        this.createMapForm();
        this.pageLoaded = true
      }
    }, error => console.error(error));
  }

  private getMapTypes() {
    this.http.get<MapType[]>(this.baseUrl + 'api/map/map-types').subscribe(result => {
      this.mapTypes = result;
    }, error => console.error(error));
  }

  private getMapSubTypes( parentId: number) {
    this.http.get<MapType[]>(this.baseUrl + 'api/map/map-sub-types?parentId=' + parentId).subscribe(result => {
      this.MapTypeSelected = true;
      this.mapSubTypes = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}
