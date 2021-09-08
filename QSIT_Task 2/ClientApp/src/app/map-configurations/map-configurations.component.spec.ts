import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MapConfigurationsComponent } from './map-configurations.component';

describe('MapConfigurationsComponent', () => {
  let component: MapConfigurationsComponent;
  let fixture: ComponentFixture<MapConfigurationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MapConfigurationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MapConfigurationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
