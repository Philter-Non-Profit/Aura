import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface AuraUserViewModel extends $models.AuraUser {
  
  /** A unique user identifying GUID */
  auraUserId: string | null;
  name: string | null;
  email: string | null;
  lastLogin: Date | null;
  houseManagers: HouseManagerViewModel[] | null;
  messages: MessageViewModel[] | null;
}
export class AuraUserViewModel extends ViewModel<$models.AuraUser, $apiClients.AuraUserApiClient, string> implements $models.AuraUser  {
  
  
  public addToHouseManagers(initialData?: DeepPartial<$models.HouseManager> | null) {
    return this.$addChild('houseManagers', initialData) as HouseManagerViewModel
  }
  
  get houses(): ReadonlyArray<HouseViewModel> {
    return (this.houseManagers || []).map($ => $.house!).filter($ => $)
  }
  
  constructor(initialData?: DeepPartial<$models.AuraUser> | null) {
    super($metadata.AuraUser, new $apiClients.AuraUserApiClient(), initialData)
  }
}
defineProps(AuraUserViewModel, $metadata.AuraUser)

export class AuraUserListViewModel extends ListViewModel<$models.AuraUser, $apiClients.AuraUserApiClient, AuraUserViewModel> {
  
  constructor() {
    super($metadata.AuraUser, new $apiClients.AuraUserApiClient())
  }
}


export interface HouseViewModel extends $models.House {
  houseId: number | null;
  name: string | null;
  address: string | null;
  
  /** The main phone number to reach the house */
  mainPhone: string | null;
  
  /** An alternate phone number to reach the house */
  altPhone: string | null;
  houseManagers: HouseManagerViewModel[] | null;
  rooms: RoomViewModel[] | null;
}
export class HouseViewModel extends ViewModel<$models.House, $apiClients.HouseApiClient, number> implements $models.House  {
  
  
  public addToHouseManagers(initialData?: DeepPartial<$models.HouseManager> | null) {
    return this.$addChild('houseManagers', initialData) as HouseManagerViewModel
  }
  
  get auraUsers(): ReadonlyArray<AuraUserViewModel> {
    return (this.houseManagers || []).map($ => $.auraUser!).filter($ => $)
  }
  
  
  public addToRooms(initialData?: DeepPartial<$models.Room> | null) {
    return this.$addChild('rooms', initialData) as RoomViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.House> | null) {
    super($metadata.House, new $apiClients.HouseApiClient(), initialData)
  }
}
defineProps(HouseViewModel, $metadata.House)

export class HouseListViewModel extends ListViewModel<$models.House, $apiClients.HouseApiClient, HouseViewModel> {
  
  constructor() {
    super($metadata.House, new $apiClients.HouseApiClient())
  }
}


export interface HouseManagerViewModel extends $models.HouseManager {
  houseManagerId: number | null;
  houseId: number | null;
  house: HouseViewModel | null;
  auraUserId: string | null;
  auraUser: AuraUserViewModel | null;
}
export class HouseManagerViewModel extends ViewModel<$models.HouseManager, $apiClients.HouseManagerApiClient, number> implements $models.HouseManager  {
  
  constructor(initialData?: DeepPartial<$models.HouseManager> | null) {
    super($metadata.HouseManager, new $apiClients.HouseManagerApiClient(), initialData)
  }
}
defineProps(HouseManagerViewModel, $metadata.HouseManager)

export class HouseManagerListViewModel extends ListViewModel<$models.HouseManager, $apiClients.HouseManagerApiClient, HouseManagerViewModel> {
  
  constructor() {
    super($metadata.HouseManager, new $apiClients.HouseManagerApiClient())
  }
}


export interface MessageViewModel extends $models.Message {
  messageId: number | null;
  messageBody: string | null;
}
export class MessageViewModel extends ViewModel<$models.Message, $apiClients.MessageApiClient, number> implements $models.Message  {
  
  constructor(initialData?: DeepPartial<$models.Message> | null) {
    super($metadata.Message, new $apiClients.MessageApiClient(), initialData)
  }
}
defineProps(MessageViewModel, $metadata.Message)

export class MessageListViewModel extends ListViewModel<$models.Message, $apiClients.MessageApiClient, MessageViewModel> {
  
  constructor() {
    super($metadata.Message, new $apiClients.MessageApiClient())
  }
}


export interface RecipientViewModel extends $models.Recipient {
  recipientId: number | null;
  recipientName: string | null;
  recipientPhoneNumber: string | null;
  messages: MessageViewModel[] | null;
}
export class RecipientViewModel extends ViewModel<$models.Recipient, $apiClients.RecipientApiClient, number> implements $models.Recipient  {
  
  constructor(initialData?: DeepPartial<$models.Recipient> | null) {
    super($metadata.Recipient, new $apiClients.RecipientApiClient(), initialData)
  }
}
defineProps(RecipientViewModel, $metadata.Recipient)

export class RecipientListViewModel extends ListViewModel<$models.Recipient, $apiClients.RecipientApiClient, RecipientViewModel> {
  
  constructor() {
    super($metadata.Recipient, new $apiClients.RecipientApiClient())
  }
}


export interface RoomViewModel extends $models.Room {
  roomId: number | null;
  houseId: number | null;
  house: HouseViewModel | null;
  name: string | null;
  notes: string | null;
}
export class RoomViewModel extends ViewModel<$models.Room, $apiClients.RoomApiClient, number> implements $models.Room  {
  
  constructor(initialData?: DeepPartial<$models.Room> | null) {
    super($metadata.Room, new $apiClients.RoomApiClient(), initialData)
  }
}
defineProps(RoomViewModel, $metadata.Room)

export class RoomListViewModel extends ListViewModel<$models.Room, $apiClients.RoomApiClient, RoomViewModel> {
  
  constructor() {
    super($metadata.Room, new $apiClients.RoomApiClient())
  }
}


export class MessagingServiceViewModel extends ServiceViewModel<typeof $metadata.MessagingService, $apiClients.MessagingServiceApiClient> {
  
  public get sendText() {
    const sendText = this.$apiClient.$makeCaller(
      this.$metadata.methods.sendText,
      (c, to: $models.PhoneNumber | null, messagingServiceId: string | null, message: string | null) => c.sendText(to, messagingServiceId, message),
      () => ({to: null as $models.PhoneNumber | null, messagingServiceId: null as string | null, message: null as string | null, }),
      (c, args) => c.sendText(args.to, args.messagingServiceId, args.message))
    
    Object.defineProperty(this, 'sendText', {value: sendText});
    return sendText
  }
  
  public get sendTextAt() {
    const sendTextAt = this.$apiClient.$makeCaller(
      this.$metadata.methods.sendTextAt,
      (c, to: $models.PhoneNumber | null, messagingServiceId: string | null, message: string | null, messageTime: Date | null) => c.sendTextAt(to, messagingServiceId, message, messageTime),
      () => ({to: null as $models.PhoneNumber | null, messagingServiceId: null as string | null, message: null as string | null, messageTime: null as Date | null, }),
      (c, args) => c.sendTextAt(args.to, args.messagingServiceId, args.message, args.messageTime))
    
    Object.defineProperty(this, 'sendTextAt', {value: sendTextAt});
    return sendTextAt
  }
  
  constructor() {
    super($metadata.MessagingService, new $apiClients.MessagingServiceApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  AuraUser: AuraUserViewModel,
  House: HouseViewModel,
  HouseManager: HouseManagerViewModel,
  Message: MessageViewModel,
  Recipient: RecipientViewModel,
  Room: RoomViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  AuraUser: AuraUserListViewModel,
  House: HouseListViewModel,
  HouseManager: HouseManagerListViewModel,
  Message: MessageListViewModel,
  Recipient: RecipientListViewModel,
  Room: RoomListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
  MessagingService: MessagingServiceViewModel,
}

