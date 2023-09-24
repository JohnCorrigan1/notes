<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditInput from './EditUtils/EditInput.vue';
import EditList from './EditUtils/EditList.vue';

const items = ref<string[]>(["", ""]);
const sectionHeader = ref("");

</script>

<template>
    <EditContainer :label="sectionHeader" type="Section Ordered list">
        <EditInput label="Section Header" v-model="sectionHeader" />
        <EditList label="Steps" v-model="items" />
    </EditContainer>
</template>