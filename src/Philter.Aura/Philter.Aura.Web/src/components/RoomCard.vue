<template>
    <CardWithIcon :title="room.name!" icon="fas fa-people-roof" :color="color">
        <template #button>
            <v-btn :color="color" density="comfortable" icon="fas fa-pencil" variant="tonal"
                @click="editRoom = !editRoom" />
        </template>
        <template #default>
            {{ room.notes }}
        </template>
    </CardWithIcon>
    <Dialog title="Edit" v-model="editRoom">
          <EditRoomForm :room="room" :houseId="room.houseId!" @saved="editRoom = false">
              <template #buttons>
                  <v-btn color="primary" variant="tonal" class="mr-3" @click="editRoom = false">Cancel</v-btn>
              </template>
          </EditRoomForm>
      </Dialog>
</template>

<script lang="ts" setup>
import { RoomViewModel } from "@/viewmodels.g";
withDefaults(
    defineProps<{
        room: RoomViewModel;
        color?: string;
    }>(),
    {
        color: "primary",
    }
);
const editRoom = ref(false);
</script>