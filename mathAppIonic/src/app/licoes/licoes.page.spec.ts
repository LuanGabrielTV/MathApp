import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LicoesPage } from './licoes.page';

describe('LicoesPage', () => {
  let component: LicoesPage;
  let fixture: ComponentFixture<LicoesPage>;

  beforeEach(async(() => {
    fixture = TestBed.createComponent(LicoesPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
