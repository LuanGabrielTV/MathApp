export class Licao{
    idLicao: number | undefined;
    nome: string | undefined;
    conteudo: string | undefined;
    recompensa: number | undefined;
    atividades: Array<any> | undefined; // trocar tipo quando inserir atividades
    matriculas: Array<any> | undefined;

    constructor(idLicao:number, nome:string, matriculas:any[], recompensa:number){
        this.idLicao = idLicao;
        this.matriculas = matriculas;
        this.nome = nome;
        this.recompensa = recompensa;
    }

}