<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditList from './EditUtils/EditList.vue';

const items = ref<string[]>(["", ""]);

</script>

<template>
    <EditContainer label="Centered Unordered list" type="Centered Unordered list">
        <EditList label="Bullets" v-model="items" />
    </EditContainer>
</template>