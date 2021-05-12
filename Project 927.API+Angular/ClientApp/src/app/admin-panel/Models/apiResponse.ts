export class ApiResponse{
    isSuccessful: boolean = false;
    message!: string;
}

export class  ApiCollectionResponse extends ApiResponse{
    data: Array<any> = [];
}