import { ProdespMonitorModalConfirmComponent } from './../components/prodesp-monitor-modal-confirm/prodesp-monitor-modal-confirm.component';
import { Observable } from 'rxjs/Observable';
import { IModal } from 'prodesp-ui';
import { DialogComponent, DialogService } from 'ng2-bootstrap-modal';
export abstract class ModalComponent<TIModal extends IModal> extends DialogComponent<TIModal, any> implements IModal {
    isClickDisabled: boolean;
    title: string;
    showConfirmButton: boolean;
    closeButtonText: string;
    confirmButtonText: string;
    modalData: any;

    constructor(dialogService: DialogService) {
        super(dialogService);
    }
  /*   showConfirmDialog(msg: string, title: string, closeButtonText: string, confirmButtonText: string): Observable<TIModal> {
        return this.dialogService.addDialog(ProdespMonitorModalConfirmComponent, {
          title: title,
          text: msg,
          closeButtonText: closeButtonText,
          confirmButtonText: confirmButtonText,
          showConfirmButton: false
        });
      }
      showAlertDialog(msg: string, title: string, closeButtonText: string): Observable<TIModal> {
        return this.dialogService.addDialog(ProdespMonitorModalConfirmComponent, {
          title: title,
          text: msg,
          closeButtonText: closeButtonText,
          showConfirmButton: false
        });
      } */
    confirm(data: any): void {
        console.log('Modal abstract component confirmed');
        this.result = data;
        this.close();
    }
    closeModal(): void {
        console.log('Modal abstract component closed');
        this.close();
    }
}
