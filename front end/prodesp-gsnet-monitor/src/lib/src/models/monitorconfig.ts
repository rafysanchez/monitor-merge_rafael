import { Injectable } from "@angular/core";

@Injectable()
export abstract class MonitorConfig {
    abstract baseApiUrl: string;
    abstract MotivoAcaoApi: string;
    abstract JustificativaAcaoApi: string;
    abstract MenusApi: string;
}
