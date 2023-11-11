<template>
    <CardWithIcon :title="room.name!" icon="fas fa-people-roof" :color="color">
        <template #default>
            {{ room.notes }}
        </template>
    </CardWithIcon>
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
</script>