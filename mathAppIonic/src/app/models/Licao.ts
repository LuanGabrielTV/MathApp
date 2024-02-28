export class Licao{
    idLicao: number | undefined;
    nome: string | undefined;
    conteudo: string | undefined;
    recompensa: number | undefined;
    atividades: Array<any> | undefined; // trocar tipo quando inserir atividades
    matriculas: matricula | undefined;
    isFinished: boolean | undefined;
    constructor(idLicao:number, nome:string, matriculas:any, recompensa:number){
        this.idLicao = idLicao;
        this.nome = nome;
        this.recompensa = recompensa;
        this.matriculas = matriculas as matricula;
    }

    
}

class matricula{
    idLicao:number | undefined;
    idUsuario: number | undefined;
    isFinished: boolean | undefined;
}