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
}
export class HouseViewModel extends ViewModel<$models.House, $apiClients.HouseApiClient, number> implements $models.House  {
  
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


const viewModelTypeLookup = ViewModel.typeLookup = {
  AuraUser: AuraUserViewModel,
  House: HouseViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  AuraUser: AuraUserListViewModel,
  House: HouseListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
}

