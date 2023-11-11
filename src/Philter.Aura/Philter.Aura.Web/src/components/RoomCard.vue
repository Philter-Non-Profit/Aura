<template>
    <CardWithIcon :title="room.name!" icon="fas fa-people-roof" :color="color">
        <template #button>
            <v-btn :color="color" density="comfortable" icon="fas fa-pencil" variant="tonal" @click="addRoom = !addRoom" />
        </template>
        <template #default>
            <div class="font-weight-bold">Notes: </div>
            <div class="text-body-2" style="overflow: auto; whiteSpace: pre-line">
                {{ room.notes }}
            </div>
        </template>
    </CardWithIcon>

    <Dialog title="Edit Room" v-model="addRoom">
        <EditRoomForm @saved="addRoom = false" :room="room">
            <template #buttons>
                <v-btn color="primary" variant="tonal" class="mr-3" @click="addRoom = false">Cancel</v-btn>
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

const addRoom = ref(false);

</script>