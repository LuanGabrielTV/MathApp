export class Atividade{
    idAtividade: number | undefined;
    enunciado: string | undefined;
    conteudo: string | undefined;
    isFinished: boolean | undefined;
    solucao: string | undefined; // trocar tipo quando inserir atividades
    questao: Array<string> | undefined;

    constructor(idAtividade:number, enunciado:string, conteudo:string, questao:string[], solucao:string){
        this.idAtividade = idAtividade;
        this.enunciado = enunciado;
        this.conteudo = conteudo;
        this.questao = questao;
        this.solucao = solucao;
    }
}