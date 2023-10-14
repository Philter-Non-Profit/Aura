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
  managedHouses: HouseViewModel[] | null;
}
export class AuraUserViewModel extends ViewModel<$models.AuraUser, $apiClients.AuraUserApiClient, string> implements $models.AuraUser  {
  
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
  managers: AuraUserViewModel[] | null;
  rooms: RoomViewModel[] | null;
}
export class HouseViewModel extends ViewModel<$models.House, $apiClients.HouseApiClient, number> implements $models.House  {
  
  
  public addToRooms() {
    return this.$addChild('rooms') as RoomViewModel
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


const viewModelTypeLookup = ViewModel.typeLookup = {
  AuraUser: AuraUserViewModel,
  House: HouseViewModel,
  Room: RoomViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  AuraUser: AuraUserListViewModel,
  House: HouseListViewModel,
  Room: RoomListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
}

