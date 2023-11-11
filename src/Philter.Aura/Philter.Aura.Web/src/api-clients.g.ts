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


export class HouseManagerApiClient extends ModelApiClient<$models.HouseManager> {
  constructor() { super($metadata.HouseManager) }
}


export class MessageApiClient extends ModelApiClient<$models.Message> {
  constructor() { super($metadata.Message) }
}


export class RecipientApiClient extends ModelApiClient<$models.Recipient> {
  constructor() { super($metadata.Recipient) }
}


export class RoomApiClient extends ModelApiClient<$models.Room> {
  constructor() { super($metadata.Room) }
}


export class MessagingServiceApiClient extends ServiceApiClient<typeof $metadata.MessagingService> {
  constructor() { super($metadata.MessagingService) }
  public sendText(to: $models.PhoneNumber | null, messagingServiceId: string | null, message: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.MessageResource>> {
    const $method = this.$metadata.methods.sendText
    const $params =  {
      to,
      messagingServiceId,
      message,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


