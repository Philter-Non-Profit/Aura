import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class AuraUserApiClient extends ModelApiClient<$models.AuraUser> {
  constructor() { super($metadata.AuraUser) }
}


export class HouseApiClient extends ModelApiClient<$models.House> {
  constructor() { super($metadata.House) }
}


