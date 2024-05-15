<template>
  <v-container>
    <c-loader-status :loaders="{ '': [houseList?.$load] }">
      <div v-if="houseList">
        <v-row>
          <v-col cols="12" md="6" lg="5" xl="4" v-if="house">
            <HouseCard :house="house" color="purple" />
          </v-col>
          <v-col cols="8" v-else>
            <v-row>
              <v-col cols="6">
                <CardWithIcon title="Create A Home" icon="fas fa-house" color="grey">
                  <template #default>
                    <EditHouseForm @saved="loadHouses()" />
                  </template>
                </CardWithIcon>
              </v-col>
            </v-row>
          </v-col>
        </v-row>
        <div v-if="house">
          <v-row class="mt-4">
            <v-col cols="12" class="d-flex pb-0">
              <div class="text-h6 mr-2">
                Rooms
              </div>
              <v-btn @click="editRoom = !editRoom" color="purple" density="comfortable" icon="fas fa-plus" variant="tonal" />
            </v-col>
            <v-col cols="12"><v-divider /></v-col>
          </v-row>
          <v-row v-if="house.rooms">
            <v-col cols="12" md="6" lg="4" xl="3" v-for="room in house.rooms" v-bind:key="room.roomId!">
              <RoomCard :room="room" color="purple" />
            </v-col>
          </v-row>
          <v-row v-else>
            <v-col cols="12" class="font-italic text-medium-emphasis">
              No rooms
            </v-col>
          </v-row>
        </div>
      </div>
      <Dialog title="Edit" v-model="editRoom">
          <EditRoomForm :room="room" :house="house!" @saved="loadHouses(); editRoom = false">
              <template #buttons>
                  <v-btn color="primary" variant="tonal" class="mr-3" @click="editRoom = false">Cancel</v-btn>
              </template>
          </EditRoomForm>
      </Dialog>
    </c-loader-status>
  </v-container>
</template>

<script setup lang="ts">
  import { HouseListViewModel, RoomViewModel } from "@/viewmodels.g";

  useTitle("Home");

  const houseList = ref<HouseListViewModel>();
  houseList.value = new HouseListViewModel();
  houseList.value.$pageSize = 100;
  houseList.value.$load();

  const house = computed(() => houseList.value?.$items[0]);
  const room: Ref<undefined | RoomViewModel> = ref(undefined);
  const editRoom = ref(false);

  function loadHouses() {
    houseList.value?.$load();
  }

</script>
