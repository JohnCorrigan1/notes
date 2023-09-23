<script setup lang="ts">
import { ref } from 'vue'
import EditTextArea from './EditUtils/EditTextArea.vue';
import EditContainer from './EditUtils/EditContainer.vue';

const paragraphBody = ref("")
</script>

<template>
    <EditContainer label="" type="Post Paragraph">
        <EditTextArea label="Paragraph Body" v-model="paragraphBody" />
    </EditContainer>
</template>