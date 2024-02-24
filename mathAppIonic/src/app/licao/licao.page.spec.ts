import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LicaoPage } from './licao.page';

describe('LicaoPage', () => {
  let component: LicaoPage;
  let fixture: ComponentFixture<LicaoPage>;

  beforeEach(async(() => {
    fixture = TestBed.createComponent(LicaoPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
