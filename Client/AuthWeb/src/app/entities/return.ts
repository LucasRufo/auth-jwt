export interface Return {
    isValid: boolean,
    erros: { [key: string]: string },
    object: object
}