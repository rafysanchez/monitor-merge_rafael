export class Menu {
    constructor( public link: string,
    public icon: string,
    public descricao: string,
    public subMenus: Menu[]= [],
    public isOpen: boolean = false) {

    }

}
