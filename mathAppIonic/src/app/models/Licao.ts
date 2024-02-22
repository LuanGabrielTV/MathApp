export class Licao{
    idLicao: number | undefined;
    nome: string | undefined;
    conteudo: string | undefined;
    recompensa: number | undefined;
    atividades: Array<any> | undefined; // trocar tipo quando inserir atividades
    matriculado: boolean | undefined;

    constructor(idLicao:number, nome:string, matriculado:boolean, recompensa:number){
        this.idLicao = idLicao;
        this.matriculado = matriculado;
        this.nome = nome;
        this.recompensa = recompensa;
    }
}